import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  productInfo: [],
  isOpen: false
} 

export const catalogDialogSlice = createSlice({
  name: 'catalogDialog',
  initialState: initialState,
  reducers: {
    open: (state, action) => {
      state.isOpen = true
      state.productInfo = action.payload
    },
    close: (state) => {
      state.isOpen = false
      state.productInfo = {}
    }
  },
})

export const { open, close } = catalogDialogSlice.actions

export default catalogDialogSlice.reducer