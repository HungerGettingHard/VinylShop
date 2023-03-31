import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  isOpen: false,
  destinations: []
} 

export const orderDialogSlice = createSlice({
  name: 'orderDialog',
  initialState: initialState,
  reducers: {
    open: (state) => {
      state.isOpen = true
    },
    close: (state) => {
      state.isOpen = false
    },
    setDestinations: (state, action) => {
      state.destinations = action.payload
    }
  },
})

export const { open, close, setDestinations } = orderDialogSlice.actions

export default orderDialogSlice.reducer