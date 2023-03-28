import { configureStore } from '@reduxjs/toolkit'
import genreReducer from '../features/genres/genresSlice'
import catalogReducer from '../features/catalog/catalogSlice'

export default configureStore({
  reducer: {
    genre: genreReducer,
    catalog: catalogReducer
  },
})