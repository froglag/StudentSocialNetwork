import { useEffect, useState } from 'react';

const SideBar = ({ studentId }) => {
    const [sideBarUrl, setSideBarUrl] = useState(null);
  const [sideBarData, setSideBarData] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadConfig = async () => {
      try {
        const response = await fetch('/UrlConnection.json');
        if (!response.ok) {
          throw new Error(`Failed to load config: ${response.status}`);
        }

        const config = await response.json();
        const apiUrl = config.Development.SideBar;
        setSideBarUrl(apiUrl);
      } catch (error) {
        console.log('Error loading config:', error);
      }
    };

    loadConfig();
  }, []);

  useEffect(() => {
    const fetchSideBarData = async () => {
        if(sideBarUrl == null) return
      try {
        const response = await fetch(`${sideBarUrl}/${studentId}`);
        if (!response.ok) {
          throw new Error(`Error fetching sidebar data`);
        }
        const data = await response.json();
        setSideBarData(data);
      } catch (error) {
        console.log(`${error}`);
      } finally {
        setLoading(false);
      }
    };

    fetchSideBarData();
  },[sideBarUrl, studentId]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (!sideBarData) {
    return <div>No data available</div>;
  }

  return (
    <div className="sidebar">
    <h3>{sideBarData.firstName} {sideBarData.lastName}</h3>
    {sideBarData.image != null ? 
    <img src={sideBarData.image} alt="Profile" /> : <p>Empty</p>}
    
    <div>
        {sideBarData.chatsName.length > 0 ? (
          sideBarData.chatsName.map((chat, index) => (
            <div key={index}>
                <p>{chat}</p>
            </div>
          ))
        ) : (
          <div><p>No Chats found</p></div>
        )}
      </div>
    </div>
  );
};

export default SideBar;

