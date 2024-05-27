import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import { FontAwesomeIcon } from '@fortawesome/react-native-fontawesome'
import { faGear, faHouse, faWallet } from '@fortawesome/free-solid-svg-icons';

import Home  from '../screens/Home/HomePage';
import Wallet  from '../screens/Wallet/WalletPage';
import Settings  from '../screens/Settings/SettingsPage';

const Tab = createBottomTabNavigator();

export default function TabRoutes() {
    return (
        <Tab.Navigator screenOptions={{ 
            headerShown: false
        }}>
            <Tab.Screen 
                name='home'
                component={Home}
                options={{ 
                    tabBarShowLabel: false,
                    tabBarIcon: ({ color, size }) => <FontAwesomeIcon icon={faHouse} color={color} size={size} />
                }} />
            <Tab.Screen 
                name='wallet'
                component={Wallet}
                options={{ 
                    tabBarShowLabel: false,
                    tabBarIcon: ({ color, size }) => <FontAwesomeIcon icon={faWallet} color={color} size={size} />
                }} />
            <Tab.Screen 
                name='setting'
                component={Settings}
                options={{ 
                    tabBarShowLabel: false,
                    tabBarIcon: ({ color, size }) => <FontAwesomeIcon icon={faGear} color={color} size={size} />
                }} />
        </Tab.Navigator>
    )
}