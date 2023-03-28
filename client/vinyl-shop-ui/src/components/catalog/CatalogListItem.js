import { Box, Typography } from "@mui/material"
import colors from '../../themes/colors'
import image from '../../assets/panic.jpg'

function CatalogListItem(props) {
  const productName = props.props.name

  return(
    <Box sx={{
      flexDirection: 'column',
      display: 'flex',
      width: 250,
      height: 300,
      backgroundColor: colors.dark,
      borderRadius: 2,
      m: 1
    }}>
    <Box component="img"
        sx={{
          borderRadius: 2,
          height: 250,
          width: 250,
        }}
        alt="Изображение"
        src={image}/>
    <Box sx={{
      display: 'flex',
      width: '100%',
      height: 100,
      flexDirection: 'row',
      justifyContent: 'center',
      alignItems: 'center' 
    }}>
      <Typography sx={{
        display: 'flex',
        fontSize: 20,
        color: colors.white,
      }}>
        {productName}
      </Typography>
    </Box>
  </Box>)
}

export default CatalogListItem