import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  products: [],
} 

export const catalogSlice = createSlice({
  name: 'catalog',
  initialState: initialState,
  reducers: {
    setAll: (state, action) => {
      state.products = action.payload
    },
  },
})

export const { setAll } = catalogSlice.actions

export default catalogSlice.reducer