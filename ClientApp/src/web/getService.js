import axios from "axios";
import getIUS from "../utils/const"

const {baseURL, getAllProducts} = getIUS;
const axiosInstance = axios.create({
    baseURL,
    timeout: 1000
})

export default async function getProducts(){
    const response = await axiosInstance.get(getAllProducts);
    return response;
}