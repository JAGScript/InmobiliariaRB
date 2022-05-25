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
    public class AdministracionCore
    {
        private static DBManager GetConnection() => new DBManager();

        #region Clientes
        public List<Cliente> ConsultarClientes(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var clientes = objData.ConsultarDatos<Cliente>("ConsultarClientes");

            if (!incluirInactivas)
                clientes = clientes.FindAll(t => t.ESTADOCLIENTE);

            return clientes;
        }

        public void ActualizarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[8]
                {
                    objData.CreateParameter("@i_id_cliente", SqlDbType.Int, 4, cliente.IDCLIENTE),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, cliente.NOMBRECLIENTE),
                    objData.CreateParameter("@i_identificacion", SqlDbType.VarChar, 10, cliente.IDENTIFICACIONCLIENTE),
                    objData.CreateParameter("@i_direccion", SqlDbType.VarChar, 200, cliente.DIRECCIONCLIENTE),
                    objData.CreateParameter("@i_celular", SqlDbType.VarChar, 10, cliente.CELULARCLIENTE),
                    objData.CreateParameter("@i_correo", SqlDbType.VarChar, 100, cliente.CORREOCLIENTE),
                    objData.CreateParameter("@i_id_asesor", SqlDbType.Int, 4, cliente.ASESOR),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, cliente.ESTADOCLIENTE)
                };

                objData.Update("ActualizarCliente", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarCliente(Cliente cliente)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_cliente", SqlDbType.Int, 4, cliente.IDCLIENTE)
            };

            objData.Delete("EliminarCliente", CommandType.StoredProcedure, parameters);
        }

        public void GuardarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[7]
                {
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, cliente.NOMBRECLIENTE),
                    objData.CreateParameter("@i_identificacion", SqlDbType.VarChar, 10, cliente.IDENTIFICACIONCLIENTE),
                    objData.CreateParameter("@i_direccion", SqlDbType.VarChar, 200, cliente.DIRECCIONCLIENTE),
                    objData.CreateParameter("@i_celular", SqlDbType.VarChar, 10, cliente.CELULARCLIENTE),
                    objData.CreateParameter("@i_correo", SqlDbType.VarChar, 100, cliente.CORREOCLIENTE),
                    objData.CreateParameter("@i_id_asesor", SqlDbType.Int, 4, cliente.ASESOR),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, cliente.ESTADOCLIENTE)
                };

                objData.Update("GuardarCliente", CommandType.StoredProcedure, parameters);
            }
        }
        #endregion

        #region Propiedades
        public List<Propiedad> ConsultarPropiedades(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var propiedades = objData.ConsultarDatos<Propiedad>("ConsultarPropiedades");

            if (!incluirInactivas)
                propiedades = propiedades.FindAll(t => t.ESTADOPROPIEDAD);

            return propiedades;
        }

        public void GuardarPropiedad(Caracteristica caracteristica, Propiedad propiedad)
        {
            int idCaracteristica = 0;

            if (caracteristica != null)
            {
                idCaracteristica = GuardarCaracteristica(caracteristica);
            }

            if (propiedad != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[7]
                {
                    objData.CreateParameter("@i_id_propietario", SqlDbType.Int, 4, propiedad.IDPROPIETARIO),
                    objData.CreateParameter("@i_id_caracteristica", SqlDbType.Int, 4, idCaracteristica),
                    objData.CreateParameter("@i_id_tipo_propiedad", SqlDbType.Int, 4, propiedad.IDTIPOPROPIEDAD),
                    objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, propiedad.IDPROVINCIA),
                    objData.CreateParameter("@i_precio", SqlDbType.Money, 8, propiedad.PRECIO),
                    objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, propiedad.IDUSUARIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, propiedad.ESTADOPROPIEDAD)
                };

                objData.Insert("GuardarPropiedad", CommandType.StoredProcedure, parameters);
            }
        }

        public void ActualizarPropiedad(Propiedad propiedad)
        {
            if (propiedad != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[6]
                {
                    objData.CreateParameter("@i_id_propiedad", SqlDbType.Int, 4, propiedad.IDPROPIEDAD),
                    objData.CreateParameter("@i_id_tipo_propiedad", SqlDbType.Int, 4, propiedad.IDTIPOPROPIEDAD),
                    objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, propiedad.IDTIPOPROPIEDAD),
                    objData.CreateParameter("@i_precio", SqlDbType.Money, 8, propiedad.PRECIO),
                    objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, propiedad.IDUSUARIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, propiedad.ESTADOPROPIEDAD)
                };

                objData.Update("ActualizarPropiedad", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarPropiedad(Propiedad propiedad)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_propiedad", SqlDbType.Int, 4, propiedad.IDPROPIEDAD)
            };

            objData.Delete("EliminarPropiedad", CommandType.StoredProcedure, parameters);
        }
        #endregion

        #region Propietarios
        public List<Propietario> ConsultarPropietarios(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var propietarios = objData.ConsultarDatos<Propietario>("ConsultarPropietarios");

            if (!incluirInactivas)
                propietarios = propietarios.FindAll(t => t.ESTADOPROPIETARIO);

            return propietarios;
        }

        public void GuardarPropietario(Propietario propietario)
        {
            if (propietario != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[5]
                {
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, propietario.NOMBREPROPIETARIO),
                    objData.CreateParameter("@i_direccion", SqlDbType.VarChar, 200, propietario.DIRECCIONPROPIETARIO),
                    objData.CreateParameter("@i_celular", SqlDbType.VarChar, 10, propietario.CELULARPROPIETARIO),
                    objData.CreateParameter("@i_correo", SqlDbType.VarChar, 100, propietario.CORRREOPROPIETARIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, propietario.ESTADOPROPIETARIO)
                };

                objData.Update("GuardarPropietario", CommandType.StoredProcedure, parameters);
            }
        }

        public void ActualizarPropietario(Propietario propietario)
        {
            if (propietario != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[6]
                {
                    objData.CreateParameter("@i_id_propietario", SqlDbType.Int, 4, propietario.IDPROPIETARIO),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 100, propietario.NOMBREPROPIETARIO),
                    objData.CreateParameter("@i_direccion", SqlDbType.VarChar, 200, propietario.DIRECCIONPROPIETARIO),
                    objData.CreateParameter("@i_celular", SqlDbType.VarChar, 10, propietario.CELULARPROPIETARIO),
                    objData.CreateParameter("@i_correo", SqlDbType.VarChar, 100, propietario.CORRREOPROPIETARIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, propietario.ESTADOPROPIETARIO)
                };

                objData.Update("ActualizarPropietario", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarPropietario(Propietario propietario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_propietario", SqlDbType.Int, 4, propietario.IDPROPIETARIO)
            };

            objData.Delete("EliminarPropietario", CommandType.StoredProcedure, parameters);
        }
        #endregion

        #region Caracteristica
        public int GuardarCaracteristica(Caracteristica caracteristica)
        {
            int id = 0;

            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[8]
            {
                objData.CreateParameter("@i_metros", SqlDbType.Decimal, 4, caracteristica.METROSCUADRADOS),
                objData.CreateParameter("@i_plantas", SqlDbType.Int, 4, caracteristica.PLANTAS),
                objData.CreateParameter("@i_banios", SqlDbType.Int, 4, caracteristica.BANIOS),
                objData.CreateParameter("@i_habitaciones", SqlDbType.Int, 4, caracteristica.HABITACIONES),
                objData.CreateParameter("@i_parqueos", SqlDbType.Int, 4, caracteristica.PARQUEADEROS),
                objData.CreateParameter("@i_servicios", SqlDbType.VarChar, 100, caracteristica.SERVICIOS),
                objData.CreateParameter("@i_otros", SqlDbType.VarChar, 150, caracteristica.OTROS),
                objData.CreateParameter("@o_id_caracteristica", SqlDbType.Int, 4, ParameterDirection.Output)
            };

            id = objData.Insert("GuardarCaracteristica", CommandType.StoredProcedure, parameters);

            return id;
        }
        #endregion
    }
}
