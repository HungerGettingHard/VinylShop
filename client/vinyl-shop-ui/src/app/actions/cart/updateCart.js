import axios from 'axios'
import { getCart } from './getCart'

export const updateCart = (cart) => {
    return async (dispatch) => {
        const response = await axios.put(`${process.env.REACT_APP_API_URL}/api/ShoppingCart/${cart.id}`, {
            amount: cart.amount
        })                
        
        dispatch(getCart())
    }
}
