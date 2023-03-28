import { configureStore } from '@reduxjs/toolkit'
import genreReducer from '../features/genres/genresSlice'

export default configureStore({
  reducer: {
    genre: genreReducer,
  },
})