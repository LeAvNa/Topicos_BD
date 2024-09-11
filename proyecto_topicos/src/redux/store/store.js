import { configureStore } from "@reduxjs/toolkit";
import { getClienteReducer } from "../slice/sliceCliente";
import { getCocteleriaReducer } from "../slice/sliceCocteleria";
import { getEmpleadoReducer } from "../slice/sliceEmpleado";
import { getInventarioReducer } from "../slice/sliceInventario";
import { getProductoReducer } from "../slice/sliceProducto";
import { getProveedorReducer } from "../slice/sliceProveedor";
import { getSucursalReducer } from "../slice/sliceSucursal";
import { getVentaReducer } from "../slice/sliceVenta";

export default configureStore({
  reducer: {
    getCliente: getClienteReducer,
    getCocteleria: getCocteleriaReducer,
    getEmpleado: getEmpleadoReducer,
    getInventario: getInventarioReducer,
    getProducto: getProductoReducer,
    getProveedor: getProveedorReducer,
    getSucursal: getSucursalReducer,
    getVenta: getVentaReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({ serializableCheck: false }),
});