import React from 'react'; 
import { View, Text, StyleSheet } from 'react-native';

import Ionicons from '@expo/vector-icons/Ionicons';
import { BaseScreen } from '../../components/baseScreen';
import { CollapseView } from '../../components/Containers/CollapseView';


export default class HomeScreen extends BaseScreen {

    render(): React.ReactNode 
    {
      return (
        <View style={styles.container}>
          <View style={styles.header}>
            <Text style={{ fontSize: 16, color: 'white' }}>Bem vindo</Text>
            <Ionicons name="settings-sharp" 
                      size={24} 
                      color="white" />
          </View>
          <View style={{ padding: 24, minHeight: 100, width: '100%'}}>
            <CollapseView title='Sua conta'></CollapseView>
          </View>
        </View>
      );
    }

}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#121214',
    flexDirection: 'column'
  },
  header: {
    height: 'auto',
    flexDirection: 'row',
    alignContent: 'center',
    justifyContent: 'space-between',
    padding: 24,
  }
});