import Inicio from "../components/pages/inicio/Inicio";
import Sucursal from "../components/pages/sucursal";


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
    }
];
export default Routes;