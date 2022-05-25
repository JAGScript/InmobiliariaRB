using InmobiliariaRB.DataAccess;
using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaRB.Logica
{
    public class CatalogoCore
    {
        private static DBManager GetConnection() => new DBManager();

        #region Pronvicias
        public List<Provincia> ConsultarProvincias(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var provincias = objData.ConsultarDatos<Provincia>("ConsultarProvincias");

            if (!incluirInactivas)
                provincias = provincias.FindAll(t => t.ESTADOPROVINCIA);

            return provincias;
        }

        public void ActualizarProvincia(Provincia provincia)
        {
            if (provincia != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[4]
                {
                    objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, provincia.IDPROVINCIA),
                    objData.CreateParameter("@i_cod_provincia", SqlDbType.VarChar, 100, provincia.CODPROVINCIA),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, provincia.NOMBREPROVINCIA),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, provincia.ESTADOPROVINCIA)
                };

                objData.Update("ActualizarProvincia", CommandType.StoredProcedure, parameters);
            }
        }

        public void GuardarProvincia(Provincia provincia)
        {
            if (provincia != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[3]
                {
                    objData.CreateParameter("@i_cod_provincia", SqlDbType.VarChar, 100, provincia.CODPROVINCIA),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, provincia.NOMBREPROVINCIA),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, provincia.ESTADOPROVINCIA)
                };

                objData.Update("GuardarProvincia", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarProvincia(int idProvincia)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                    objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, idProvincia)
            };

            objData.Update("EliminarProvincia", CommandType.StoredProcedure, parameters);
        }
        #endregion

        #region Cantones
        public List<Canton> ConsultarCantones(int? idProvincia = null, bool incluirInactivas = false)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, idProvincia)
            };

            var cantones = objData.ConsultarDatos<Canton>("ConsultarCantones", parameters);

            if (!incluirInactivas)
                cantones = cantones.FindAll(t => t.ESTADOCANTON);

            return cantones;
        }

        public void ActualizarCanton(Canton canton)
        {
            if (canton != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[5]
                {
                    objData.CreateParameter("@i_id_canton", SqlDbType.Int, 4, canton.IDCANTON),
                    objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, canton.IDPROVINCIA),
                    objData.CreateParameter("@i_cod_canton", SqlDbType.VarChar, 100, canton.CODCANTON),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, canton.NOMBRECANTON),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, canton.ESTADOCANTON)
                };

                objData.Update("ActualizarCanton", CommandType.StoredProcedure, parameters);
            }
        }

        public void GuardarCanton(Canton canton)
        {
            if (canton != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[4]
                {
                    objData.CreateParameter("@i_id_provincia", SqlDbType.VarChar, 100, canton.IDPROVINCIA),
                    objData.CreateParameter("@i_cod_canton", SqlDbType.VarChar, 100, canton.CODCANTON),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, canton.NOMBRECANTON),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, canton.ESTADOCANTON)
                };

                objData.Update("GuardarCanton", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarCanton(int idCanton)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                    objData.CreateParameter("@i_id_canton", SqlDbType.Int, 4, idCanton)
            };

            objData.Update("EliminarCanton", CommandType.StoredProcedure, parameters);
        }
        #endregion

        #region Parroquias
        public List<Parroquia> ConsultarParroquias(int? idCanton = null, bool incluirInactivas = false)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_canton", SqlDbType.Int, 4, idCanton)
            };

            var parroquias = objData.ConsultarDatos<Parroquia>("ConsultarParroquias", parameters);

            if (!incluirInactivas)
                parroquias = parroquias.FindAll(t => t.ESTADOPARROQUIA);

            return parroquias;
        }

        public void ActualizarParroquia(Parroquia parroquia)
        {
            if (parroquia != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[5]
                {
                    objData.CreateParameter("@i_id_parroquia", SqlDbType.Int, 4, parroquia.IDPARROQUIA),
                    objData.CreateParameter("@i_id_canton", SqlDbType.Int, 4, parroquia.IDCANTON),
                    objData.CreateParameter("@i_codigo", SqlDbType.VarChar, 100, parroquia.CODPARROQUIA),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, parroquia.NOMBRECANTON),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, parroquia.ESTADOPARROQUIA)
                };

                objData.Update("ActualizarParroquia", CommandType.StoredProcedure, parameters);
            }
        }

        public void GuardarParroquia(Parroquia parroquia)
        {
            if (parroquia != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[4]
                {
                    objData.CreateParameter("@i_id_canton", SqlDbType.VarChar, 100, parroquia.IDCANTON),
                    objData.CreateParameter("@i_codidgo", SqlDbType.VarChar, 100, parroquia.CODPARROQUIA),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, parroquia.NOMBRECANTON),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, parroquia.ESTADOPARROQUIA)
                };

                objData.Update("GuardarParroquia", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarParroquia(int idParroquia)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                    objData.CreateParameter("@i_id_parroquia", SqlDbType.Int, 4, idParroquia)
            };

            objData.Update("EliminarParroquia", CommandType.StoredProcedure, parameters);
        }
        #endregion

        #region Barrios
        public List<Barrio> ConsultarBarrios(int? idParroquia = null, bool incluirInactivas = false)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_parroquia", SqlDbType.Int, 4, idParroquia)
            };

            var barrios = objData.ConsultarDatos<Barrio>("ConsultarBarrios", parameters);

            if (!incluirInactivas)
                barrios = barrios.FindAll(t => t.ESTADOBARRIO);

            return barrios;
        }

        public void ActualizarBarrio(Barrio barrio)
        {
            if (barrio != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[4]
                {
                    objData.CreateParameter("@i_id_barrio", SqlDbType.Int, 4, barrio.IDBARRIO),
                    objData.CreateParameter("@i_id_parroquia", SqlDbType.Int, 4, barrio.IDPARROQUIA),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, barrio.NOMBREBARRIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, barrio.ESTADOBARRIO)
                };

                objData.Update("ActualizarBarrio", CommandType.StoredProcedure, parameters);
            }
        }

        public void GuardarBarrio(Barrio barrio)
        {
            if (barrio != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[3]
                {
                    objData.CreateParameter("@i_id_parroquia", SqlDbType.VarChar, 100, barrio.IDPARROQUIA),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, barrio.NOMBREBARRIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, barrio.ESTADOBARRIO)
                };

                objData.Update("GuardarBarrio", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarBarrio(int idBarrio)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                    objData.CreateParameter("@i_id_barrio", SqlDbType.Int, 4, idBarrio)
            };

            objData.Update("EliminarBarrio", CommandType.StoredProcedure, parameters);
        }
        #endregion


        #region TiposPropiedad
        public List<TipoPropiedad> ConsultarTiposPropiedad(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var tipos = objData.ConsultarDatos<TipoPropiedad>("ConsultarTiposPropiedad");

            if (!incluirInactivas)
                tipos = tipos.FindAll(t => t.ESTADOTIPOPROPIEDAD);

            return tipos;
        }

        public void ActualizarTiposPropiedad(TipoPropiedad tipo)
        {
            if (tipo != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[3]
                {
                    objData.CreateParameter("@i_id_tipo", SqlDbType.Int, 4, tipo.IDTIPOPROPIEDAD),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, tipo.NOMBRETIPOPROPIEDAD),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, tipo.ESTADOTIPOPROPIEDAD)
                };

                objData.Update("ActualizarTipoPropiedad", CommandType.StoredProcedure, parameters);
            }
        }

        public void GuardarTiposPropiedad(TipoPropiedad tipo)
        {
            if (tipo != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[2]
                {
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, tipo.NOMBRETIPOPROPIEDAD),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, tipo.ESTADOTIPOPROPIEDAD)
                };

                objData.Update("GuardarTipoPropiedad", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarTiposPropiedad(int idTipo)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                    objData.CreateParameter("@i_id_tipo", SqlDbType.Int, 4, idTipo)
            };

            objData.Update("EliminarTipoPropiedad", CommandType.StoredProcedure, parameters);
        }
        #endregion
    }
}
