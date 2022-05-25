using InmobiliariaRB.DataAccess;
using InmobiliariaRB.Model.Shared;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace InmobiliariaRB.Logica
{
    public class SeguridadCore
    {
        private static DBManager GetConnection() => new DBManager();

        public Usuario ConsultarUsuario(string nombreUsuario)
        {
            var objData = GetConnection();

            Usuario usuario = null;

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_nombre_usuario", SqlDbType.VarChar, 30, nombreUsuario)
            };

            var usuarios = objData.ConsultarDatos<Usuario>("ConsultarUsuario", parameters);

            if (usuarios != null && usuarios.Count() > 0)
                usuario = usuarios.FirstOrDefault();

            return usuario;
        }

        public bool ValidarPasswordUsuario(Usuario usuario, string password)
        {
            var objData = GetConnection();

            bool valido = false;

            IDbDataParameter[] parameters = new IDbDataParameter[3]
            {
                objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, usuario.IDUSUARIO),
                objData.CreateParameter("@i_password", SqlDbType.VarChar, 300, password),
                objData.CreateParameter("@o_valido", SqlDbType.Bit, 1, ParameterDirection.Output)
            };

            var retorno = objData.Execute("ValidarPasswordUsuario", CommandType.StoredProcedure, parameters);

            if (retorno != null && retorno.Count() > 0)
            {
                var datoRetorno = (SqlParameter)retorno[0];

                if (datoRetorno.SqlDbType == SqlDbType.Bit)
                    valido = (bool)datoRetorno.Value;
            }

            return valido;
        }

        public List<Transaccion> ConsultarTransaccionesUsuario(string loginUsuario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_nombre_usuario", SqlDbType.VarChar, 30, loginUsuario)
            };

            var transacciones = objData.ConsultarDatos<Transaccion>("ConsultarTransaccionesUsuario", parameters);

            return transacciones;
        }

        public List<Transaccion> ConsultarSubMenuUsuario(string loginUsuario, int menuPadre)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[2]
            {
                objData.CreateParameter("@i_nombre_usuario", SqlDbType.VarChar, 30, loginUsuario),
                objData.CreateParameter("@i_menu_padre", SqlDbType.Int, 4, menuPadre)
            };

            var transacciones = objData.ConsultarDatos<Transaccion>("ConsultarSubMenuUsuario", parameters);

            return transacciones;
        }

        #region Transacciones

        public List<Transaccion> ConsultarTransacciones(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var transacciones = objData.ConsultarDatos<Transaccion>("ConsultarTransacciones");

            if (!incluirInactivas)
                transacciones = transacciones.FindAll(t => t.ESTADO);

            return transacciones;
        }

        public void ActualizarTransaccion(Transaccion transaccion, Usuario usuario)
        {
            if (transaccion != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[4]
                {
                    objData.CreateParameter("@i_id_transaccion", SqlDbType.Int, 4, transaccion.IDTRANSACCION),
                    objData.CreateParameter("@i_descripcion", SqlDbType.VarChar, 300, transaccion.DESCRIPCION),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, transaccion.ESTADO),
                    objData.CreateParameter("@i_id_usuario_modificacion", SqlDbType.Int, 4, usuario.IDUSUARIO)
                };

                objData.Update("ActualizarTransaccion", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarTransaccion(Transaccion transaccion, Usuario usuario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[2]
            {
                objData.CreateParameter("@i_id_transaccion", SqlDbType.Int, 4, transaccion.IDTRANSACCION),
                objData.CreateParameter("@i_id_usuario_modificacion", SqlDbType.Int, 4, usuario.IDUSUARIO)
            };

            objData.Delete("EliminarTransaccion", CommandType.StoredProcedure, parameters);
        }

        #endregion

        #region Roles de Seguridad

        public List<Rol> ConsultarRolesSeguridad(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var roles = objData.ConsultarDatos<Rol>("ConsultarRoles");

            if (!incluirInactivas)
                roles = roles.FindAll(e => e.ESTADOROL);

            return roles;
        }

        public int GuardarRolSeguridad(Rol rol, Usuario usuario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[2]
            {
                objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 30, rol.NOMBREROL),
                objData.CreateParameter("@o_id_rol_seguridad", SqlDbType.Int, 4, ParameterDirection.Output)
            };

            var idRol = objData.Insert("GuardarRol", CommandType.StoredProcedure, parameters);

            return idRol;
        }

        public void GuardarRol(Rol rol, Usuario usuario)
        {
            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required))
            {
                var idRol = GuardarRolSeguridad(rol, usuario);

                if (rol.Transacciones != null && rol.Transacciones.Count() > 0)
                {
                    foreach (var item in rol.Transacciones)
                    {
                        GuardarTransaccionRolSeguridad(idRol, item.IDTRANSACCION);
                    }
                }

                tran.Complete();
            }
        }

        public void ActualizarRolSeguridad(Rol rolSeguridad, Usuario usuario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[4]
            {
                objData.CreateParameter("@i_id_rol_seguridad", SqlDbType.Int, 4, rolSeguridad.IDROL),
                objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 30, rolSeguridad.NOMBREROL),
                objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, rolSeguridad.ESTADOROL),
                objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, usuario.IDUSUARIO)
            };

            objData.Update("ActualizarRolSeguridad", CommandType.StoredProcedure, parameters);
        }

        public void ActualizarRol(Rol rol, Usuario usuario)
        {
            if (rol.Transacciones == null)
                rol.Transacciones = new List<Transaccion>();

            var transaccionesIniciales = ConsultarTransaccionesRolSeguridad(rol.IDROL);

            var transaccionesGuardar = rol.Transacciones.FindAll(e => !transaccionesIniciales.Exists(i => i.IDTRANSACCION == e.IDTRANSACCION));
            var transaccionesEliminar = transaccionesIniciales.FindAll(i => !rol.Transacciones.Exists(e => e.IDTRANSACCION == i.IDTRANSACCION));

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required))
            {
                ActualizarRolSeguridad(rol, usuario);

                if (transaccionesGuardar != null && transaccionesGuardar.Count() > 0)
                {
                    foreach (var item in transaccionesGuardar)
                    {
                        GuardarTransaccionRolSeguridad(rol.IDROL, item.IDTRANSACCION);
                    }
                }

                if (transaccionesEliminar != null && transaccionesEliminar.Count() > 0)
                {
                    foreach (var item in transaccionesEliminar)
                    {
                        EliminarTransaccionRolSeguridad(item.IDTRANSACCIONROL);
                    }
                }

                tran.Complete();
            }
        }

        public void EliminarRolSeguridad(Rol rolSeguridad, Usuario usuario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[2]
            {
                objData.CreateParameter("@i_id_rol_seguridad", SqlDbType.Int, 4, rolSeguridad.IDROL),
                objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, usuario.IDUSUARIO)
            };

            objData.Delete("EliminarRolSeguridad", CommandType.StoredProcedure, parameters);
        }

        public List<Transaccion> ConsultarTransaccionesRolSeguridad(int idRolSeguridad)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_rol_seguridad", SqlDbType.Int, 4, idRolSeguridad)
            };

            var transacciones = objData.ConsultarDatos<Transaccion>("ConsultarTransaccionesRolSeguridad", parameters);

            return transacciones;
        }

        public void GuardarTransaccionRolSeguridad(int idRolSeguridad, int idTransaccion)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[2]
            {
                objData.CreateParameter("@i_id_rol_seguridad", SqlDbType.Int, 4, idRolSeguridad),
                objData.CreateParameter("@i_id_transaccion", SqlDbType.Int, 4, idTransaccion)
            };

            objData.Insert("GuardarTransaccionRolSeguridad", CommandType.StoredProcedure, parameters);
        }

        public void EliminarTransaccionRolSeguridad(int idTransaccionRolSeguridad)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_transaccion_rol_seguridad", SqlDbType.Int, 4, idTransaccionRolSeguridad)
            };

            objData.Delete("EliminarTransaccionRolSeguridad", CommandType.StoredProcedure, parameters);
        }

        #endregion

        #region Usuarios
        public List<Usuario> ConsultarUsuarios(bool incluirInactivas = false)
        {
            var objData = GetConnection();

            var usuarios = objData.ConsultarDatos<Usuario>("ConsultarUsuarios");

            if (!incluirInactivas)
                usuarios = usuarios.FindAll(t => t.ESTADO);

            return usuarios;
        }

        public void ActualizarUsuario(Usuario usuario, string contrasena)
        {
            if (usuario != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[7]
                {
                    objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, usuario.IDUSUARIO),
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 50, usuario.NOMBREUSUARIO),
                    objData.CreateParameter("@i_identificacion", SqlDbType.VarChar, 15, usuario.IDENTIFICACIONUSUARIO),
                    objData.CreateParameter("@i_username", SqlDbType.VarChar, 50, usuario.USERNAME),
                    objData.CreateParameter("@i_id_rol", SqlDbType.Int, 4, usuario.IDROL),
                    objData.CreateParameter("@i_contrasena", SqlDbType.VarChar, 50, contrasena),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, usuario.ESTADO)
                };

                objData.Update("ActualizarUsuario", CommandType.StoredProcedure, parameters);
            }
        }

        public void EliminarUsuario(Usuario usuario)
        {
            var objData = GetConnection();

            IDbDataParameter[] parameters = new IDbDataParameter[1]
            {
                objData.CreateParameter("@i_id_usuario", SqlDbType.Int, 4, usuario.IDUSUARIO)
            };

            objData.Delete("EliminarUsuario", CommandType.StoredProcedure, parameters);
        }

        public void GuardarUsuario(Usuario usuario, string contrasena)
        {
            if (usuario != null)
            {
                var objData = GetConnection();

                IDbDataParameter[] parameters = new IDbDataParameter[6]
                {
                    objData.CreateParameter("@i_nombre", SqlDbType.VarChar, 50, usuario.NOMBREUSUARIO),
                    objData.CreateParameter("@i_identificacion", SqlDbType.VarChar, 15, usuario.IDENTIFICACIONUSUARIO),
                    objData.CreateParameter("@i_username", SqlDbType.VarChar, 50, usuario.USERNAME),
                    objData.CreateParameter("@i_id_rol", SqlDbType.Int, 4, usuario.IDROL),
                    objData.CreateParameter("@i_contrasena", SqlDbType.VarChar, 50, contrasena),
                    objData.CreateParameter("@i_estado", SqlDbType.Bit, 1, usuario.ESTADO)
                };

                objData.Update("GuardarUsuario", CommandType.StoredProcedure, parameters);
            }
        }
        #endregion

        #region Asesores
        public List<Usuario> ConsultarAsesores()
        {
            List<Usuario> usuarios = null;

            usuarios = ConsultarUsuarios();

            if (usuarios != null)
            {
                usuarios = usuarios.FindAll(u => u.IDROL == 2);//Asesores
            }

            return usuarios;
        }
        #endregion
    }
}
