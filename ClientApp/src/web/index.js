import axios from 'axios'
import baseURL from '../utils/const'

const axiosInstance = axios.create({
    baseURL,
    timeout: 1000
})

export default axiosInstance;