import { Box } from "@mui/material";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { setProfile } from '../features/sideMenuSlice'
import ProfileBox from "../components/profile/ProfileBox";

function ProfilePage() {
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(setProfile())
  }, [])

  return(
    <Box sx={{
      display: 'flex',
      alignItems: 'center',
      pt: '120px',
      flexDirection: 'column',
      width: '100%'
    }}>
      <ProfileBox/>
    </Box>
  );
}

export default ProfilePage