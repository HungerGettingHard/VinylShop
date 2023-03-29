import { useDispatch, useSelector } from "react-redux"
import colors from "../../themes/colors"
import { Box, ButtonBase, Typography } from "@mui/material"
import CloseIcon from '@mui/icons-material/Close';
import { close } from '../../features/catalog/catalogDialogSlice'
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';

function CatalogDialog() {
  const productInfo = useSelector(store => store.catalogDialog.productInfo)
  const dispatch = useDispatch()

  const onClose = () => {
    dispatch(close())
  }

  return(
    <Box sx={{
      position: "fixed",
      height: 400,
      width: 750,
      backgroundColor: colors.dark,
      borderRadius: 2,
      display: 'flex',
    }}>
      <Box component="img"
        sx={{
          borderRadius: 2,
          height: 400,
          width: 400,
        }}
        alt="Изображение"
        src={productInfo.image}/>
      <ButtonBase onClick={onClose} sx={{
        position: 'absolute',
        height: 38,
        width: 38,
        right: 2,
        top: 2
      }}>
        <CloseIcon sx={{ color: colors.white }}/>
      </ButtonBase>

      {/* Цена и кнопка */}
      <Box sx={{
        width: '100%',
        height: 360,
        m: 5,
        display: 'flex',
        flexDirection: 'column'
      }}>
        {/* Заголовок */}
        <Typography sx={{
          width: '100%',
          height: 80,
          fontSize: 25,
          fontWeight: 'bold',
          display: "flex",
          color: colors.white,  
          overflow: 'hidden', 
        }} align='center'>
          {productInfo.name}
        </Typography>

        {/* Описание */}
        <Typography sx={{
          width: '100%',
          height: 200,
          fontSize: 14,
          fontWeight: 'bold',
          color: colors.white,
          overflow: 'hidden',
        }}>
          {productInfo.description}
        </Typography>
        
        <Box sx={{
          display: 'flex',
          mb: 2,
          height: 78,
          alignItems: 'center',
          justifyContent: 'space-between  '
        }}>
        <Typography sx={{
          fontSize: 25,
          fontWeight: 'bold',
          width: '70%',
          display: 'flex',
          alignItems: 'center', 
          color: colors.white,  
        }}>{`Цена: ${productInfo.price}`}</Typography>
        <ButtonBase sx={{
          width: 40,
          height: 40,
          borderRadius: 2,
          backgroundColor: colors.purple  
        }}>
          <AddShoppingCartIcon sx={{
            color: colors.white
          }}/>
        </ButtonBase>
        </Box>
      </Box>

      {/* Жанры */}
      <Box sx={{
        position: 'absolute',
        height: 50,
        bottom: -50,
        width: '100%',
        display: 'flex',
        justifyContent: 'center', 
        flexWrap: 'wrap'
      }}>
        {productInfo.genres.map((genre) => <Typography key={genre.id} sx={{
          backgroundColor: colors.purple,
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
          padding: 1,
          margin: 0.5,
          mt: 1,
          minWidth: 85,
          color: colors.white,
          fontSize: 20,
          borderRadius: 2 
        }}>{genre.name}</Typography>)}
      </Box>
    </Box>)
}

export default CatalogDialog