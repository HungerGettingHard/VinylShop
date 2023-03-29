import { ButtonBase, Typography } from "@mui/material"
import { useState } from "react"
import colors from '../../themes/colors'
import { setSelectedItem, removeSelectedItem } from "../../features/genres/genresSlice"
import { useDispatch } from "react-redux"

function GenreSelectorItem(props) {
  const genreName = props.props.name
  const genreId = props.props.key 
  const [isSelected, setIsSelected] = useState(true);
  const dispatch = useDispatch()

  const handleGenreClick = () => {
    if (isSelected) {
      dispatch(removeSelectedItem(genreId))
    } else {
      dispatch(setSelectedItem(genreId))
    }
    
    setIsSelected(!isSelected)    
  }

  return(
    <ButtonBase sx={{
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center',
      padding: 1,
      margin: 0.5,
      minWidth: 85,
      borderRadius: 2,
      backgroundColor: isSelected ? colors.purple : null,
    }} onClick={handleGenreClick}>
      <Typography sx={{
        display: 'flex',
        fontSize: 20,
        color: isSelected ? colors.white : colors.gray
      }}>
        {genreName}
      </Typography>
    </ButtonBase>
  )
}

export default GenreSelectorItem