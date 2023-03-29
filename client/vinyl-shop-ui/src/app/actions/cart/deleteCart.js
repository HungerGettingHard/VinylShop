import axios from 'axios'
import { getCart } from './getCart'

export const deleteCart = (cartItemId) => {
    return async (dispatch) => {
        const response = await axios.delete(`${process.env.REACT_APP_API_URL}/api/ShoppingCart/${cartItemId}`)
                
        dispatch(getCart())
    }
}

