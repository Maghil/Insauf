import time
from selenium import webdriver
from selenium.common.exceptions import TimeoutException
from selenium.common.exceptions import NoSuchElementException
from selenium.common.exceptions import WebDriverException
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
import os

def cashewNut():
    #return(os.path.abspath("Insauf.exe"))
    return(r'C:\Users\MMMM\.vscode\python')

#function to write out people who dont follow you
def nonfollowers() :
    print('\n')
    set1=set()
    set2=set()
    path=cashewNut()
    with open(path+r'\CashewNut\followers.txt', 'r') as file1:
        with open(path+r'\CashewNut\following.txt', 'r') as file2:
            temp =file1.read().splitlines()
            for i in temp:
                set1.add(i)
            temp =file2.read().splitlines()
            for i in temp:
                set2.add(i)
    set3 = set2.difference(set1)
    with open(path+r'\CashewNut\non_followers.txt', 'w') as file_out:
        for line in set3:
            file_out.write(line+'\n')


#method to scrape actual data(url,filename to write to)     (does not return anything)
def scrape1(a,b,driver):
    try:
        time.sleep(2)
        driver.get('https://www.instagram.com/accounts/access_tool/'+a)

        #code to scroll down iteratively
        try:
            while(True):
                driver.find_element_by_xpath("//button[@type='button']").click()
                time.sleep(2)
                driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
                time.sleep(2)
        except:
            pass
        name=driver.find_elements_by_css_selector('div.-utLf')

        #code to copy data to a file
        with open(b, 'w') as file1:
            for el in name:
                file1.write(el.text+'\n')

    except WebDriverException as e:
        raise e
    except TimeoutException as e:
        raise e

#method to prepare webdriver for scraping using selenium(username,password)     (return 1/0)
def scrape(a,b):
    try:
        flag,driver=login(a,b,0)
        if(flag == 0) :
            path=cashewNut()
            scrape1("accounts_following_you",path+r'\CashewNut\followers.txt',driver)
            scrape1("accounts_you_follow",path+r'\CashewNut\following.txt',driver)
            return(0)

    except TimeoutException:
        return(1)
    except WebDriverException as e:
         return(2)
    finally:
        driver.quit()



#method to login using selenium(username/emailid,password) returns(driver instance,status)
def login(a,b,c):
    try:
        flag=1        
        args = ["hide_console"]
        options = webdriver.ChromeOptions()
        options.add_argument("--start-maximized")
        # options.add_argument('--headless')
        # options.add_argument('--disable-gpu')

        #no chrome or prompt
        driver = webdriver.Chrome('C:\Program Files\chromedriver_win32\chromedriver.exe', chrome_options=options,service_args=args)

        driver.get("https://www.instagram.com/accounts/login/?hl=en&source=auth_switcher")
        time.sleep(3)
        username = driver.find_element_by_name("username")
        username.clear()
        username.send_keys(a)
        time.sleep(3)
        password = driver.find_element_by_name("password")
        password.clear()
        password.send_keys(b)
        time.sleep(3)
        driver.find_element_by_xpath("//button[@type='submit']").click()

        try:
            WebDriverWait(driver, 10).until(EC.presence_of_element_located((By.CSS_SELECTOR, 'div.eiCW-')))
        except:
            flag=0
        if(flag==0):

            if(c==0):                                               #to get driver and flag
                return(flag,driver)

            else:                                                     #to get count and flag
                try:
                    time.sleep(3)
                    driver.get("https://www.instagram.com/"+a+"/?hl=en")
                    elm = driver.find_elements_by_class_name('g47SY ')
                    return([flag,elm[1].text,elm[2].text])
                finally:
                    driver.quit()

        else:
            return(1,0)

    except TimeoutException as e:
        return(2,0)
    except WebDriverException as e:
        return(3,0)

#unfollows people by selenium(filename that contains who to unfollow)
def unfollow(a,b):
    try :
        driver,flag=login(a,b,0)
        if(flag == 0) :
            #change of code
            #with open(path+r'\CashewNut\non_followers.txt','r') as myfile:
            #    head = [next(myfile) for x in range(15)]
            #with open(path+r'\CashewNut\non_followers.txt','r') as file1 :
            #    lines=file1.readlines()
            #with open(path+r'\CashewNut\non_followers.txt','r') as file2:
            #    file2.writelines(lines[15:])
            #change of code ends
            with open(path+r'\CashewNut\non_followers.txt','r') as file1:
                for line in head:
                    driver.get("https://www.instagram.com/"+line+"/?hl=en")
                    try:
                        time.sleep(5)
                        form_element = driver.find_element_by_xpath("//button[@class='_5f5mN    -fzfL     _6VtSN     yZn4P   ']").click()
                        time.sleep(5)
                        form_element = driver.find_element_by_xpath("//button[@class='aOOlW -Cab_   ']").click()
                        time.sleep(15)
                    except NoSuchElementException as exception:
                        pass
                else:
                   return(0)
        else:
            return(1)

    except TimeoutException as e:
        return(2)
    except WebDriverException as e:
        return(3)


# print(scrape("the_enigmatic_beach","a6cmMEAT"))
# print(nonfollowers())
print(unfollow("the_enigmatic_beach","a6cmMEAT"))
