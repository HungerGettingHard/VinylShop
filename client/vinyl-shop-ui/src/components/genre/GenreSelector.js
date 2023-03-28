import { Box, Typography } from "@mui/material";
import colors from '../../themes/colors'
import GenreSelectorItem from "./GenreSelectorItem";
import { useDispatch, useSelector } from 'react-redux' 
import { getGenres } from "../../app/actions/genre";
import { useEffect } from "react";

function GenreSelector() {
  const genres = useSelector(state => state.genre.genres) 
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getGenres())
  }, [])

  return(
    <Box sx={{
      display: 'flex',
      height: '100%', 
      width: '20%',
      boxShadow: 2,
      backgroundColor: colors.white,
      flexDirection: 'column'
    }}>
      {genres.map((genre) =>
        <GenreSelectorItem key={genre.key} props={genre}/>)}
    </Box>
  );
}

export default GenreSelector