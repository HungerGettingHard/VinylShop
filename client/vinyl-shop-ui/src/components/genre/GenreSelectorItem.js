import { ButtonBase, Typography } from "@mui/material"
import { useState } from "react"
import colors from '../../themes/colors'

function GenreSelectorItem(props) {
  const genreName = props.props.name
  const [isSelected, setIsSelected] = useState(true);

  const handleGenreClick = () => {
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