import axios from 'axios'
import { setDestinations } from '../../../features/order/orderDialogSlice'

export const getDestinations = () => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/OrderDestination`)                
        
        const destinations = response.data.map((destination) => { return ({
            id: destination.id,
            name: destination.name 
        })})

        dispatch(setDestinations(destinations))
    }
}

