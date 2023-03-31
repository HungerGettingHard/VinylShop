import axios from 'axios'
import { getCart } from '../cart/getCart'

export const makeOrder = (destinationId) => {
    return async (dispatch) => {
        const response = await axios.post(`${process.env.REACT_APP_API_URL}/api/Order`, {
                orderDestinationId: destinationId,
                shoppingCartId: process.env.REACT_APP_CART_ID
            })
                
        dispatch(getCart())
    }
}

