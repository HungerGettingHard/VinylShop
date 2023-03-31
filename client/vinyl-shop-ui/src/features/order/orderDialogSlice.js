import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  isOpen: false,
  destinations: [],
  selectedDestination: ''
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
      state.destinations = action.payload.map((dest) => {
        return({
          id: dest.id,
          name: dest.name,
          isSelected: false
        })})
    },
    selectDestination: (state, action) => {
      state.destinations = state.destinations.map((dest) => {
        if (action.payload !== dest.id) {
          return({
            id: dest.id,
            name: dest.name,
            isSelected: false
        })}
        else {
          state.selectedDestination = action.payload
          return({
            id: dest.id,
            name: dest.name,
            isSelected: true
        })}
      })
    }
  },
})

export const { open, close, setDestinations, selectDestination } = orderDialogSlice.actions

export default orderDialogSlice.reducer