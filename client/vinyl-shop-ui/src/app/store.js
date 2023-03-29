import { configureStore } from '@reduxjs/toolkit'
import genreReducer from '../features/genres/genresSlice'
import catalogReducer from '../features/catalog/catalogSlice'
import catalogDialogReducer from '../features/catalog/catalogDialogSlice'
import menuReducer from '../features/sideMenuSlice'
import cartReducer from '../features/cart/cartSlice'

export default configureStore({
  reducer: {
    genre: genreReducer,
    catalog: catalogReducer,
    catalogDialog: catalogDialogReducer,
    menu: menuReducer,
    cart: cartReducer
  },
})