import axios from 'axios'
import { setAll } from '../../../features/cart/cartSlice'

export const getCart = () => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/ShoppingCart/${process.env.REACT_APP_PERSON_ID}`)                
        
        const cartItems = response.data.items.map((item) => { return({
            id: item.cartItemId,
            amount: item.amount,
            productId: item.productId,
            name: item.productName,
            image: item.imageLink,
            price: item.price
        })})

        dispatch(setAll(cartItems))
    }
}

