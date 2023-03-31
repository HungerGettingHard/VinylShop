import { Box, Typography } from "@mui/material"
import { useDispatch } from "react-redux"
import colors from '../../themes/colors'

function ProfileOrderListItem(props) {
  const order = props.order
  const dispatch = useDispatch()

  const calculatePrice = (items) => {
    let price = 0

    items.forEach((item) => {
      price += item.price
    })

    return price
  }

  return(
    <Box sx={{
      width: '100%',
      height: 150,
      mt: 1,
      backgroundColor: colors.dark,
      borderRadius: 2,
      display: 'flex',
      flexDirection: 'row'
    }}>
      <Box sx={{
        height: 150,
        width: '85%',
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        overflow: 'scroll'
      }}>
        {order.orderItems.map((item) => 
        <Box key={item.id} component="img" sx={{
          borderRadius: 2,
          height: 140,
          width: 140,
          ml: 1
          }}
        alt="Изображение"
        src={item.imageLink}/>)}
      </Box>

      <Box sx={{
        height: 150,
        width: "15%",
        backgroundColor: colors.purple,
        borderRadius: 2,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
      }}>
        <Typography sx={{
          color: colors.white
        }}>
          {`Стоимость: ${calculatePrice(order.orderItems)}`}
        </Typography>
      </Box>
    </Box>
  )  
}

export default ProfileOrderListItem