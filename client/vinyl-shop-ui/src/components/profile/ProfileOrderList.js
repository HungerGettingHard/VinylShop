import { Box } from "@mui/material"
import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { getOrders } from "../../app/actions/order/getOrders"
import ProfileOrderListItem from './ProfileOrderListItem'
import colors from '../../themes/colors'

function ProfileOrderList() {
  const orders = useSelector(store => store.order.orders)
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getOrders())
  }, [])

  return(
    <Box sx={{
      flexDirection: 'column',
      flexWrap: 'wrap',
      display: 'flex',
      justifyContent: 'center', 
      pb: 1
    }}>
      {orders.map((order) => <ProfileOrderListItem key={order.id} order={order}/>)}
    </Box>
  )  
}

export default ProfileOrderList