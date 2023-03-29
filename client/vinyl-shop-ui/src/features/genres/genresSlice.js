import { createSlice } from '@reduxjs/toolkit'

const initialState = {
  genres: [],
  selectedGenres: []
} 

export const genreSlice = createSlice({
  name: 'genre',
  initialState: initialState,
  reducers: {
    setAll: (state, action) => {
      state.genres = action.payload.genres
      state.selectedGenres = action.payload.genreIds
    },
    setSelectedItem: (state, action) => {
      state.selectedGenres.push(action.payload) 
    },
    removeSelectedItem: (state, action) => {
      const index = state.selectedGenres.indexOf(action.payload)
      state.selectedGenres.splice(index, 1)
    }
  },
})

export const { setAll, setSelectedItem, removeSelectedItem } = genreSlice.actions

export default genreSlice.reducer