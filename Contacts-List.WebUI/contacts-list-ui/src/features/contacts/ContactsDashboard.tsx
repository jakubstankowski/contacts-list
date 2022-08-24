import { useStore } from '../../../app/stores/store';
import React, { useEffect } from 'react';
import { observer } from 'mobx-react-lite';

export default observer(function ContactsDashboard() {
    const {contactsStore} = useStore();
    const {loadContacts, contactsRegistry} = contactsStore;

    useEffect(() => {
        if ( contactsRegistry.size <= 1) loadContacts();
      }, [contactsRegistry.size, loadContacts])


    return(
        <div>
            contact!
        </div>
    )

}