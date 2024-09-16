import Inicio from "../components/pages/inicio/Inicio";
import Sucursal from "../components/pages/sucursal";
import Sucursal2 from "../components/pages/tienda2/sucursal";


const Routes = [
    {
        path: '/',
        component: Inicio,
    },
    {
        path: '/sucursal',
        component: Sucursal
    },
    {
        path: '/sucursal/guardar',
        component: Sucursal
    },
    {
        path: '/sucursalB',
        component: Sucursal2
    },
    {
        path: '/sucursalB/guardar',
        component: Sucursal2
    },
];
export default Routes;