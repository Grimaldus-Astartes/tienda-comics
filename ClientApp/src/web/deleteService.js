import axiosInstance from ".";
import { deleteProduct } from "../utils/const";

export default async function deleteProducto(idProducto = 0) {
  const response = await axiosInstance.delete(`${deleteProduct}/${idProducto}`);
  return response;
}
