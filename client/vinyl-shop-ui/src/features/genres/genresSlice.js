import { createSlice } from '@reduxjs/toolkit'
import axios from 'axios'

const initialState = {
  genres: [{ key: 1, name: "name"}],
  selectedGenres: []
} 

export const genreSlice = createSlice({
  name: 'genre',
  initialState: initialState,
  reducers: {
    setAll: (state, action) => {
      state.genres = action.payload
      state.selectedGenres = action.payload
    },
  },
})

export const { setAll } = genreSlice.actions

export default genreSlice.reducer