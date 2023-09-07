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
    element: <Form title={"Agregar producto"} formType="crear" />
  },
  {
    path: '/producto/:idProducto',
    element: <Producto />
  },
  {
    path: '/editarProducto/:idProducto',
    element: <Form title="Editar Producto" formType="editar" />
  }
];

export default AppRoutes;
