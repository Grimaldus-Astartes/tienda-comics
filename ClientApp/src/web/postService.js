import axiosInstance from "./index";
import { postProduct } from "../utils/const";

const defaultState = {
  nombre: "",
  genero: "",
  fabricante: "",
  proveedor: "",
  existencia: 0,
  precio: 0,
  tipo: "",
};

export default async function postAProduct(producto = defaultState) {
  console.log("Post Service");
  const response = await axiosInstance.post(
    postProduct,
    JSON.stringify(producto),
    {
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  return response;
}
