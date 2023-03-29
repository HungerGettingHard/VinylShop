import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  cartItems: [],
} 

export const cartSlice = createSlice({
  name: 'cart',
  initialState: initialState,
  reducers: {
    setAll: (state, action) => {
      state.cartItems = action.payload
    },
  },
})

export const { setAll } = cartSlice.actions

export default cartSlice.reducer