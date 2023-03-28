import { Box } from "@mui/material";
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
      width: '100%',
      justifyContent: 'flex-start', 
      flexWrap: 'wrap'
    }}>
      {genres.map((genre) => <GenreSelectorItem key={genre.key} props={genre}/>)}
    </Box>
  );
}

export default GenreSelector