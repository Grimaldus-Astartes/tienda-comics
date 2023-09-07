import axiosInstance from ".";
import { updateProduct } from "../utils/const";

const defaultState = {
  nombre: "",
  genero: "",
  fabricante: "",
  proveedor: "",
  existencia: 0,
  precio: 0,
  tipo: "",
};

export default async function updateProducto(
  idProducto = 0,
  producto = defaultState
) {
  const response = await axiosInstance.put(
    `${updateProduct}/${idProducto}`,
    producto,
    {
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
}
