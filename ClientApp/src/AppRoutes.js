import { Counter } from "./components/Counter";
import Form from './components/Form'
import Dashboard from './components/Dashboard'
import Producto from "./components/Producto";

const AppRoutes = [
  {
    index: true,
    element: <Dashboard />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/form',
    element: <Form title={"Agregar producto"} />
  },
  {
    path: '/producto/:idProducto',
    element: <Producto />
  }
];

export default AppRoutes;
