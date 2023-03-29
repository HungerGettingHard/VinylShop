import axios from 'axios'

export const addCart = (productId) => {
    return async (dispatch) => {
        const response = await axios.post(`${process.env.REACT_APP_API_URL}/api/ShoppingCart`, {
                productId: productId,
                shoppingCartId: process.env.REACT_APP_CART_ID
            })
                
        console.log(response.data)
    }
}

