import { Counter } from "./components/Counter";
import Form from './components/Form'
import Dashboard from './components/Dashboard'

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
  }
];

export default AppRoutes;
