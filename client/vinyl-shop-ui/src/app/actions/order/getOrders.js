import axios from 'axios'
import { setAll } from "../../../features/order/orderSlice";

export const getOrders = () => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/Order`)

        console.log(response.data)
        dispatch(setAll(response.data))
    }
}
