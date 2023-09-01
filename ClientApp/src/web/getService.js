import axiosInstance from './index'
import { getAllProducts } from '../utils/const'


export default async function getProducts(){
    const response = await axiosInstance.get(getAllProducts);
    return response;
}