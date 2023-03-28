import axios from 'axios'
import { setAll } from "../../features/catalog/catalogSlice";

export const getProducts = () => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/Product`)
        const products = response.data.map((product) => {
            return ({
                key: product.id,
                name: product.name
            })
        })
        dispatch(setAll(products))
    }
}
