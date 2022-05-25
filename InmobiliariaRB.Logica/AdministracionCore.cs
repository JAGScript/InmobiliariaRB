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

        public void GuardarPropiedad(Propiedad propiedad)
        {
            if (propiedad != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[5]
                {
                    objData.CreateParameter("@i_id_tipo_propiedad", SqlDbType.Int, 4, propiedad.IDTIPOPROPIEDAD),
                    objData.CreateParameter("@i_id_provincia", SqlDbType.Int, 4, propiedad.IDTIPOPROPIEDAD),
                    objData.CreateParameter("@i_precio", SqlDbType.Money, 8, propiedad.PRECIO),
                    objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, propiedad.IDUSUARIO),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, propiedad.ESTADOPROPIEDAD)
                };

                objData.Update("GuardarPropiedad", CommandType.StoredProcedure, parameters);
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
    }
}
