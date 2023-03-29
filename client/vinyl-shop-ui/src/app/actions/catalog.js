import axios from 'axios'
import { setAll } from "../../features/catalog/catalogSlice";
import * as qs from 'qs'

export const getProducts = (genreIds) => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/Product`, {
            params: {
                genreIds: genreIds
            }, 
            headers: {
                accept: 'text/plain'
            },
            paramsSerializer:  {
                serialize: (params) => qs.stringify(params, {arrayFormat: 'repeat'})
            }})

        const products = response.data.map((product) => {
            return ({
                key: product.id,
                name: product.name,
                image: product.imageLink,
                price: product.price,
                genres: product.genres,
                description: product.description
            })})
        
        dispatch(setAll(products))
    }
}
