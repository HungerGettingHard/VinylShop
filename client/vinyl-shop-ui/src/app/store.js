import { configureStore } from '@reduxjs/toolkit'
import genreReducer from '../features/genres/genresSlice'
import catalogReducer from '../features/catalog/catalogSlice'
import catalogDialogReducer from '../features/catalog/catalogDialogSlice'

export default configureStore({
  reducer: {
    genre: genreReducer,
    catalog: catalogReducer,
    catalogDialog: catalogDialogReducer
  },
})