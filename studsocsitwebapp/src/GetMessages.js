import {useEffect, useState} from "react";

export const Messages = ({chatId}) => {
    const [messages, setMessages] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try{
                const response = await fetch(url);
                if(!response.ok){
                    throw new Error(`Response status: ${response.status}`);
                }

                const data = await response.json;
                setMessages(data);
            }catch(ex){
                console.error(ex.message);
            }
        }
        fetchData()
    }, [chatId])

    return messages;
}