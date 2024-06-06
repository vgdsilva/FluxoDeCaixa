import { createStackNavigator } from '@react-navigation/stack';
import { FontAwesomeIcon } from '@fortawesome/react-native-fontawesome'
import { faGear, faHouse, faWallet } from '@fortawesome/free-solid-svg-icons';

import MenuPrincipalScreen from '../../screens/MenuPrincipal';
import NavigationBar from '../../components/navigation/CustomNavigationBar';

const Stack = createStackNavigator();

export default function StackRoutes() {

    return (
        <Stack.Navigator screenOptions={{ header: (props) => <NavigationBar /> }}>
            <Stack.Screen name='MenuPrincipal' 
                          component={MenuPrincipalScreen}
                          />
        </Stack.Navigator>
    )
}