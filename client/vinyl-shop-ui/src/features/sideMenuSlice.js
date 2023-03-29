import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  isCatalogOpen: false,
  isCartOpen: false,
  isProfileOpen: false
} 

export const sideMenuSlice = createSlice({
  name: 'sideMenu',
  initialState: initialState,
  reducers: {
    setCatalog: (state) => {
      state.isCatalogOpen = true
      state.isCartOpen = false
      state.isProfileOpen = false
    },
    setCart: (state) => {
      state.isCatalogOpen = false
      state.isCartOpen = true
      state.isProfileOpen = false
    },
    setProfile: (state) => {
      state.isCatalogOpen = false
      state.isCartOpen = false
      state.isProfileOpen = true
    },
  },
})

export const { setCart, setProfile, setCatalog } = sideMenuSlice.actions

export default sideMenuSlice.reducer