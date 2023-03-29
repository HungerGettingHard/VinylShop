import { Box, ButtonBase, Typography } from "@mui/material"
import colors from '../../themes/colors'
import MenuIcon from '@mui/icons-material/Menu';
import { useDispatch } from "react-redux";
import { open } from '../../features/catalog/catalogDialogSlice'

function CatalogListItem(props) {
  const product = { ...props.product }
  const dispatch = useDispatch()

  const onOpenProduct = () => {
    dispatch(open(product))
  }

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
        src={product.image}/>
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
        ml: 3, mr: 3,
      }}
      noWrap={true}>
        {product.name}
      </Typography>
    </Box>
    <ButtonBase sx={{
      position: 'absolute',
      width: 35,
      height: 35,
      backgroundColor: colors.purple,
      m: 1,
      borderRadius: 2,
      boxShadow: 4,
    }} onClick={onOpenProduct}>
      <MenuIcon sx={{
        color: colors.white
      }}/>
    </ButtonBase>
  </Box>)
}

export default CatalogListItem