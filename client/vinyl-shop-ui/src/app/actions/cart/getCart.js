import axios from 'axios'

export const getCart = () => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/ShoppingCart/${process.env.REACT_APP_PERSON_ID}`)
                
        console.log(response.data)
    }
}

