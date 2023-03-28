import axios from 'axios'
import { setAll } from "../../features/genres/genresSlice";

export const getGenres = () => {
    return async (dispatch) => {
        const response = await axios.get(`${process.env.REACT_APP_API_URL}/api/Genre`)
        const genres = response.data.map((genre) => {
            return ({
                key: genre.id,
                name: genre.name
            })
        })
        dispatch(setAll(genres))
    }
}
