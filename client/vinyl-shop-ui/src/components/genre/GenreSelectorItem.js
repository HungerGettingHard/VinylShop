import { Box, Checkbox, Typography } from "@mui/material"
import colors from '../../themes/colors'

function GenreSelectorItem(props) {
  const genreName = props.props.name

  return(
    <Box sx={{
      width: '100%',
      flexDirection: 'row',
      display: 'flex',
      alignItems: 'center'
    }}>
      <Checkbox defaultChecked sx={{
        color: colors.darkRed,
        '&.Mui-checked': {
          color: colors.darkRed
        }
      }}/>
      <Typography sx={{
        display: 'flex',
        width: 2,
        fontSize: 20
      }}>
        {genreName}
      </Typography>
    </Box>
  )
}

export default GenreSelectorItem