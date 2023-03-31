import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  orders: [],
} 

export const orderSlice = createSlice({
  name: 'order',
  initialState: initialState,
  reducers: {
    setAll: (state, action) => {
      state.orders = action.payload
    },
  },
})

export const { setAll } = orderSlice.actions

export default orderSlice.reducer